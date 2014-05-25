using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docular.Client.Events
{
    /// <summary>
    /// Traces events from the caching system.
    /// </summary>
    [EventSource(Name = "Cache")]
    public class CacheEventSource : EventSource
    {
        /// <summary>
        /// Logs when an item was stored inside the cache.
        /// </summary>
        /// <param name="itemName">The name of the item.</param>
        /// <param name="storeName">The name of the store the item was stored in.</param>
        /// <param name="itemSize">The size of the item in bytes.</param>
        [Conditional("LOGGING_VERBOSE")]
        [Event(000,
               Message = "An item '{0}' (size: {1} bytes) was stored in store '{2}'.",
               Level = EventLevel.Verbose,
               Opcode = EventOpcode.Send)]
        public void ItemStored(String itemName, String storeName, long itemSize)
        {
            this.WriteEvent(
                000,
                itemName,
                itemSize,
                storeName
            );
        }

        /// <summary>
        /// Logs when an item was retreived from the cache.
        /// </summary>
        /// <param name="itemName">The name of the item.</param>
        /// <param name="storeName">The name of the store the item was stored in.</param>
        /// <param name="itemSize">The size of the item in bytes.</param>
        [Conditional("LOGGING_VERBOSE")]
        [Event(001,
               Message = "An item '{0}' (size: {1} bytes) was retreived from store '{2}'.",
               Level = EventLevel.Verbose,
               Opcode = EventOpcode.Receive)]
        public void ItemReceived(String itemName, String storeName, long itemSize)
        {
            this.WriteEvent(
                001,
                itemName,
                itemSize,
                storeName
            );
        }

        /// <summary>
        /// Logs when a specific store of the cache was invalidated.
        /// </summary>
        /// <param name="storeName">The name of the invalidated store.</param>
        [Event(002,
               Message = "Store '{0}' was invalidated..",
               Level = EventLevel.Informational,
               Opcode = EventOpcode.Info)]
        public void Invalidated(String storeName)
        {
            this.WriteEvent(
                002,
                storeName
            );
        }

        /// <summary>
        /// Logs when an item could not be found in the cache.
        /// </summary>
        /// <param name="itemName">The name of the item.</param>
        /// <param name="storeName">The name of the store of the item.</param>
        [Event(100,
               Message = "The item '{0}' to be retreived from store '{1}' could not be found.",
               Level = EventLevel.Warning,
               Opcode = EventOpcode.Receive)]
        public void ItemNotFound(String itemName, String storeName)
        {
            this.WriteEvent(
                100,
                itemName,
                storeName
            );
        }
    }
}

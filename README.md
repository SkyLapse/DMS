Docular DMS
===

A distributed document management system, released under [MIT license] (https://github.com/SkyLapse/DMS/blob/master/LICENSE.md).

### General
- When referring to Docular DMS (Namespaces, Class names, etc.), simply use "Docular" (without DMS-suffix)
- Every piece of code shall be documented

### Python-Coding Standard
- See the [Python coding standard](http://legacy.python.org/dev/peps/pep-0008/#a-foolish-consistency-is-the-hobgoblin-of-little-minds) for further information

### C#-Coding Standard
- Mostly regular C# coding conventions
- Allman indentation style
 - Single-line auto-properties, multi-line manually implemented properties
 - Don't nest consecutive IDisposable-using statements, [see this] (http://stackoverflow.com/a/9396092/2000501) instead
- 'using'-Statements:
 - ... go to the top of the code file
 - ... are directly followed by typedefs, separated by a blank line
 - Do not remove default using statements
- Avoid stacking attribute declarations. Put them in one line if possible, grouped by their function (e.g. all serializing attributes go on one line)

#### Happy coding!

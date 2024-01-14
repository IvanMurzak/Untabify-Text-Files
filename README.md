# Untabify Text Files
![___](https://img.shields.io/badge/.NET_8.0-blue.svg)
![___](https://img.shields.io/badge/Windows-black.svg)
![___](https://img.shields.io/badge/Linux-black.svg)
![___](https://img.shields.io/badge/MacOS-black.svg)
![___](https://img.shields.io/badge/Console-tool-pink.svg)

![Header](Assets/header.png)

Console tool for untabifying files. Replaces tabs to spaces at entire the text line and keeps vertical alignment.


# Commands

##  Untabify text files in folder

``` bash
untabify folder
```

```xml
Description:
  Untabify text files in folder

Usage:
  Untabify folder <folder> [options]

Arguments:
  <folder>  Folder path

Options:
  t, tab-size <tab-size>  Tab size in space characters. [default: 4]
  s, search <search>      Filter files by search pattern. Example: '*.cs'. [default: *]
  r, recursively          Process files recursively in all subfolders [default: True]
```

## Untabify text file

``` bash
untabify file
```

```xml
Description:
  Untabify text file

Usage:
  Untabify file <file> [options]

Arguments:
  <file>  File path

Options:
  t, tab-size <tab-size>  Tab size in space characters. [default: 4]
```

---

![Art](Assets/art.png)
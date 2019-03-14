[![NuGet Status](http://img.shields.io/nuget/v/Uncover.Fody.svg?style=flat&max-age=86400)](https://www.nuget.org/packages/Uncover.Fody/)

![Icon](https://github.com/mniak/Uncover/blob/master/package_icon.png)

This is a simple solution used to illustrate how to [write a Fody addin](https://github.com/Fody/Home/blob/master/pages/addin-development.md).


## Usage

See also [Fody usage](/pages/usage.md).


### NuGet installation

Install the [Uncover.Fody NuGet package](https://www.nuget.org/packages/Uncover.Fody/) and update the [Fody NuGet package](https://www.nuget.org/packages/Fody/):

```powershell
PM> Install-Package Fody
PM> Install-Package Uncover.Fody
```

The `Install-Package Fody` is required since NuGet always defaults to the oldest, and most buggy, version of any dependency.


### Add to FodyWeavers.xml

Add `<Uncover/>` to [FodyWeavers.xml](https://github.com/Fody/Home/blob/master/pages/configuration.md#fodyweaversxml)

```xml
<?xml version="1.0" encoding="utf-8" ?>
<Weavers>
  <Uncover/>
</Weavers>
```


## The moving parts

See [writing an addin](https://github.com/Fody/Home/blob/master/pages/addin-development.md)


## Icon

<a href="https://thenounproject.com/term/hidden/2200583/" target="_blank">hidden</a> designed by <a href="https://thenounproject.com/coquet_adrien/" target="_blank">Adrien Coquet</a> from The Noun Project

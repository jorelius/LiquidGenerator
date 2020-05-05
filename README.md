# LiquidGenerator

Apply Liquid templates to a data source (e.g. json)

![.NET Core](https://github.com/jorelius/LiquidGenerator/workflows/.NET%20Core/badge.svg)


### Install ###

```console
$ dotnet tool install liquid -g
```

### Usage ###

```console
$ liquid apply -t ./liquidTemplate.lt -d ./jsonrequest.json -o ./report.html
```
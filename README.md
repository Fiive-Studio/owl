# Owl Framework

![Fiive](https://fiivestudio.com/wp-content/uploads/2020/06/Fiive-Open-Source_2.png)

Owl es un framework para hacer transformaciones de formatos de documentos utilizando como base el lenguaje Xml.

## Comenzando 🚀

El framework esta desarrollado con .Net Standard 2.0 y toda la documentación de uso para el usuario final se encuentra en el sitio web [Owl Documentation](https://owl.fiivestudio.com/).

La documentación se encuentra versionada en el repositorio [Owl Docs](https://github.com/Fiive-Studio/owl-docs)

### Pre-requisitos 📋

Para utilizar el framework solo se debe importar las librerías en el proyecto y crear un archivo Owl Config que traiga la información del mapeo de los documentos.

### Instalación 🔧

Las librerias del framework se encuentran disponibles via Nuget Package:

Core: [nuget](https://www.nuget.org/packages/Fiive.Owl.Core/)

    Install-Package Fiive.Owl.Core -Version 1.0.1

Output Formats: [nuget](https://www.nuget.org/packages/Fiive.Owl.Formats/)

    Install-Package Fiive.Owl.Formats -Version 1.0.0

FlatFile Adapter: [nuget](https://www.nuget.org/packages/Fiive.Owl.Flatfile/)

    Install-Package Fiive.Owl.Flatfile -Version 1.0.1

EDI Adapter: [nuget](https://www.nuget.org/packages/Fiive.Owl.EDI/)

    Install-Package Fiive.Owl.EDI -Version 1.0.0

ANSI Adapter: [nuget](https://www.nuget.org/packages/Fiive.Owl.ANSI/)

    Install-Package Fiive.Owl.ANSI -Version 1.0.0

## Ejecutando las pruebas ⚙️

La solución del proyecto cuenta con proyectos de pruebas unitarias intregadas a las herramientas de Visual Studio, para ejecutarlas solo utilice el explorador de pruebas que provee el IDE.

## Construido con 🛠️

* [Visual Studio](https://visualstudio.microsoft.com/) - IDE
* [Microsoft .Net](https://dotnet.microsoft.com/) - Framework

## Autores ✒️

*  **[Pablo Díaz](https://fiivestudio.com/pablo-diaz/)**

## Notas Adicionales

* Fiive Studio te invita a que utilices este Framework en tus proyectos
* Si tienes alguna duda del uso del Framewokr no dudes en contactarnos por medio de nuestras redes o por medio de la sección de Issues del repositorio
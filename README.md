# Waybill 

<!-- TABLE OF CONTENTS -->
## Table of Contents

* [About the Project](#about-the-project)
  * [Built With](#built-with)
* [Getting Started](#getting-started)
* [Usage](#usage)
* [Contact](#contact)



<!-- ABOUT THE PROJECT -->
## About The Project

Application was made to make work of my friends from old department much easier and quicker. Instead of manually copying and pasting informations from first excel file to the second excel file. Application uses 2 excel files to create waybill template in excel format. First - the source, contains a lot of informations about all placed orders, Second one is a template to which read specified data from first file is inserted. Application uses a database with 2 tables in it. First table is named 'Computers' it contains all computer models which occurs in a source file with info of: model name, price, weight. Second table is named 'Localisations' it contains all localisations which occurs and are often used in a source file with info of: street, city, zip code.

### Built With
I have built this application using:
* [.NET Core 3.1](https://docs.microsoft.com/pl-pl/dotnet/core/) - console application
* [Entity Framework Core](https://docs.microsoft.com/pl-pl/ef/core/) 
* [AutoMapper](https://automapper.org) 
* [EPPLUS](https://github.com/JanKallman/EPPlus) - To work with excel files


<!-- GETTING STARTED -->
## Getting Started

In ```properties``` of project click ```debug``` and set arguments```sourceFilePath``` to path of downloaded ```SourceFile.xlsx```, ```templateFilePath``` to path of downloaded ```TemplateFile.xlsx``` and ```savingDirectory``` to saving directory which in you want to have created files and ```SenderSettingsJsonPath``` to path of downloaded ```SenderSettings.json```

## Usage

Run the application, set range of rows to be copied from source file and then file will be created. 

<!-- CONTACT -->
## Contact

My Email  - arek.pazola1998@gmail.com

Project Link: [https://github.com/w00lfer/Waybill-Application](https://github.com/w00lfer/Waybill-Application)


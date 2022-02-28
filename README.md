# EnergyPlus.Net
 A client library to create/modify/extend EnergyPlus simulation files in a way that feels natural to programmers with native type support, integrated documentation and automatic serialization. The days of string replacement in IDF text snippets, creating manual wrapper classes and worry about proper serialization are over.

![Create Simulation file](/docs/Images/Example.png)

 The entire toolkit was generated through [EPJSONToFramework](https://github.com/usaluz/EPJSONToFramework) out of the offical [epJSON-Schema](https://eplus.readthedocs.io/en/latest/index.html) which was generated from the IDD of EnergyPlus V-9-5-0. As there were no manual modifications made, this offers the possbility to upgrade to future versions or if necessary compile older versions.


## Functionality

- Creating/Extending EnergyPlus simulation files
- Merging IDF + IDF, epJSON + epJSON, IDF + epJSON
- Bidirectional translation between IDF <-> epJSON

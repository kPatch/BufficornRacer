// SPDX-License-Identifier: MIT
pragma solidity ^0.8.4;

import "@openzeppelin/contracts/token/ERC721/ERC721.sol";
import "@openzeppelin/contracts/utils/Strings.sol";


contract BufficornRacers is ERC721 {
    constructor() ERC721("Bufficorn Racers", "BUFFRACER") {}

    uint public counter;

    string[] metadata;

    string public MetadataURL = "https://raw.githubusercontent.com/kPatch/BufficornRacer/main/Metadata/Metadata/";

    function mint(address _address) public {
        metadata[counter] = string.concat(string.concat(MetadataURL,Strings.toString(counter)),".json");
        _safeMint(_address, counter++);
    }
}

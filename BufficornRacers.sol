// SPDX-License-Identifier: MIT
pragma solidity ^0.8.4;

import "@openzeppelin/contracts/token/ERC721/ERC721.sol";

contract MyToken is ERC721 {
    constructor() ERC721("Bufficorn Racers", "BUFFRACER") {}

    uint public counter;

    function mint(address _address) public {
        _safeMint(_address, counter++);
    }
}

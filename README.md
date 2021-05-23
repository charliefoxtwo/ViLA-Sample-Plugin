# ViLA Sample Plugin

[![.NET 5 CI build](https://github.com/charliefoxtwo/ViLA-Sample-Plugin/actions/workflows/ci-build.yml/badge.svg?branch=develop)](https://github.com/charliefoxtwo/ViLA-Sample-Plugin/actions/workflows/ci-build.yml)
[![GitHub](https://img.shields.io/github/license/charliefoxtwo/ViLA-Sample-Plugin?style=flat-square)](LICENSE)
[![Discord](https://img.shields.io/discord/840762843917582347?style=flat-square)](https://discord.gg/rWAF3AdsKT)

ViLA Sample Plugin is a plugin for ViLA written as both a small demonstration of how to write a plugin, as well as a tool for testing to verify that ViLA works as expected.


## Demo

![Demo](https://thumbs.gfycat.com/NervousColdBrontosaurus-size_restricted.gif)


## Installation

Unzip the release into your `Plugins` folder in ViLA. Then, copy the `ViLASamplePluginConfiguration` folder into your ViLA `Configuration` folder. After that, just run ViLA!


## Troubleshooting

#### My device isn't lighting up

This plugin supports any board in slave mode, and most devices except for the CM1 throttle in usb direct mode. However, it's possible I'm missing some PIDs for some devices.

Use Virpil's LED tool (packaged with the VPC Software Suite) to test that you can set LEDs on your device that way. If not, contact Virpil support. If so, reach out to me on [Discord](https://discord.gg/rWAF3AdsKT).


## Acknowledgements

- [readme tools](https://readme.so)
- [badges](https://shields.io)

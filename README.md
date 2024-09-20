# BizSocket

An extension for BizHawk that allows for socket communication. The extension creates a client socket for connecting to a server socket. It is compatible with the latest version of Bizhawk at the time of writing:
- BizHawk release 2.9.1
- Bizhawk candidate build 2.10-rc1

This extension is meant to be used in conjunction with a server that can receive and send messages to the client. The server can be written in any language that supports socket communication. An example server is provided in the `server` directory. How you implement the server or what features are added to the client is up to you.

## Installation

1. Download the latest (compatible) release from the [official Bizhawk releases page](https://github.com/TASEmulators/BizHawk/releases). You are not required to download the source code, but you may do so if you wish to compile it yourself.

    If you already have a Bizhawk installation, you can skip this step.
2. Extract or move the built Bizhawk project to a folder named `BizHawk` in the root of this repository.
3. Run `launch_server.bat` to start an example server. The server will be listening on port `12345` by default.
4. Run `launch_bizhawk.bat` to start Bizhawk with the extension loaded. If you have not started a server, you will be
met with an error message prompting you to start a server.

You should see a menu added. If you load a ROM, you should start seeing messages appear containing the frame count.

If all functions as expected, you can now start developing your own server and client features.

## Issues and Contributing

Please open an issue if you encounter any problems. If you would like to contribute, feel free to open a pull request.


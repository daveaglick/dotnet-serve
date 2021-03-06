﻿// Copyright (c) Nate McMaster.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.ComponentModel.DataAnnotations;
using System.Net;
using McMaster.Extensions.CommandLineUtils;

namespace McMaster.DotNet.Server
{
    [Command(
        Name = "dotnet serve",
        FullName = "dotnet-serve",
        Description = "Provides a simple HTTP server")]
    [HelpOption]
    class CommandLineOptions
    {
        [Option(Description = "The root directory to serve. [Current directory]")]
        [DirectoryExists]
        public string Directory { get; }

        [Option(Description = "Port to use [8080]. Use 0 for a dynamic port.")]
        [Range(0, 65535, ErrorMessage = "Invalid port. Ports must be in the range of 0 to 65535.")]
        public int Port { get; } = 8080;

        [Option("-a|--address <ADDRESS>", Description = "Address to use [0.0.0.0]")]
        public IPAddress[] Addresses { get; }

        [Option(Description = "Open a web browser when the server starts. [false]")]
        public bool OpenBrowser { get; }

        [Option("--path-base <PATH>", Description = "The base URL path of postpended to the site url.")]
        public string PathBase { get; private set; }

        [Option("--razor", Description ="Enable Razor Pages support (Experimental)")]
        public bool EnableRazor { get; set; }
    }
}

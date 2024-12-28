// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

import { dotnet } from './_framework/dotnet.js'

const { setModuleImports, getAssemblyExports, getConfig } = await dotnet
    .withDiagnosticTracing(false)
    .withApplicationArgumentsFromQuery()
    .create();

setModuleImports('main.js', {
    setMainLoop: (cb) => dotnet.instance.Module.setMainLoop(cb)
});

dotnet.instance.Module.canvas = document.getElementById("canvas");

await dotnet.run();
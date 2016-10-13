#ChatterBox API

To setup chatterbox, do the following:
*   Install .NET Core Framework
*   Install the [CLI](https://github.com/dotnet/cli) for the .NET Core Framework
*   Ensure that the command `dotnet resolve` can be run
*   Once that is done run `dotnet ef database update`
*   Finally run `dotnet run` and the web app should be available on http://localhost:5000/

## Problems?
### Where's DNX
Not here around anymore. This code uses .NET Core Framework RTM which changed many of the old commands
### localhost:5000 doesn't appear to work
Check your firewall settings for connectivity

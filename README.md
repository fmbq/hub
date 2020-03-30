# Digital scorekeeping project

Information related to a new project to bring a realtime, digital scorekeeping system to Free Methodist Bible quizzing events. Currently at the planning stage.

## Development

The backend server is written in C# and [.NET Core], and the frontend is written with [Vue.js]. You will need [Node.js], NPM, and .NET Core SDK installed. To compile and run both locally for development, first install project dependencies:

```sh
dotnet restore
npm install
```

Then run the server in development mode:

```sh
npm run watch
```

The development server will be listening at <http://localhost:5000>. Hot reloading is supported; changes to frontend files will be reflected in an open web browser immediately, and changes to backend files will recompile and restart the server automatically.

## License

This project is distributed under the terms of the Apache License (Version 2.0). See [LICENSE](LICENSE) for details.


[.NET Core]: https://dotnet.microsoft.com
[Node.js]: https://nodejs.org
[Vue.js]: https://vuejs.org

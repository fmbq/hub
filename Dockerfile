FROM mcr.microsoft.com/dotnet/core/sdk:3.1
WORKDIR /app
COPY . ./
RUN dotnet restore
RUN dotnet publish -c Release -o out server/src/server.csproj

FROM node:12
WORKDIR /app
COPY package*.json ./
RUN npm ci
COPY . ./
RUN npm run build

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=0 /app/out .
COPY --from=1 /app/wwwroot wwwroot
EXPOSE 80
ENTRYPOINT ["/app/server"]

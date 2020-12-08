FROM mcr.microsoft.com/dotnet/framework/aspnet:4.8-windowsservercore-ltsc2019 as installer

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop';$ProgressPreference='silentlyContinue';"]

RUN Invoke-WebRequest -OutFile nodejs.zip -UseBasicParsing "https://nodejs.org/dist/v12.4.0/node-v12.4.0-win-x64.zip"; `
CMD ["Expand-Archive", "nodejs.zip", "-DestinationPath", "C:\;" ]
CMD ["Rename-Item", "C:\\node-v12.4.0-win-x64", "C:\nodejs"]

FROM mcr.microsoft.com/windows/nanoserver:1803

WORKDIR C:/nodejs
COPY --from=installer C:/nodejs/ .
RUN SETX PATH C:\nodejs
RUN npm config set registry https://registry.npmjs.org/

WORKDIR /app

# install and cache app dependencies
COPY package.json /Client/package.json

WORKDIR /Client
RUN npm install
RUN npm install -g @angular/cli@latest

# add app
COPY . /app

# start app
CMD cd /app/src/WebSpa && ng serve --host 0.0.0.0

FROM mcr.microsoft.com/dotnet/framework/aspnet:4.8-windowsservercore-ltsc2019

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

# Install Windows components required for WCF service hosted on IIS
RUN Add-WindowsFeature NET-WCF-TCP-Activation45; \
Add-WindowsFeature NET-WCF-HTTP-Activation45; \
Add-WindowsFeature Web-WebSockets

WORKDIR Api
RUN powershell -NoProfile -Command \
    Import-module IISAdministration; \
    New-IISSite -Name "Api" -PhysicalPath C:\Api -BindingInformation "*:83:"
EXPOSE 83
COPY . .
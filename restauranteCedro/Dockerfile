FROM microsoft/dotnet:2.2-aspnetcore-runtime
WORKDIR /app
EXPOSE 5000
COPY publish_output .
ENTRYPOINT ["dotnet", "sistema-restaurante.dll"]

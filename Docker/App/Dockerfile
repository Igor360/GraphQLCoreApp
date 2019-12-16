FROM microsoft/dotnet:2.2-sdk
COPY . /app
WORKDIR /app
RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]
EXPOSE 80/tcp
RUN chmod +x ./Docker/App/entrypoint.sh
CMD /bin/bash ./Docker/App/entrypoint.sh
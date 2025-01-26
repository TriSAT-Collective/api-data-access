FROM mcr.microsoft.com/dotnet/aspnet:9.0

WORKDIR /app

ARG REPO_SOURCE=https://github.com/TriSAT-Collective/api-data-access
ARG DESCRIPTION="query smart-meter and weather data"
ARG ARTIFACT_PATH=dist/

ARG ENTRYPOINT=/app/api-data-access
ENV ENTRYPOINT=$ENTRYPOINT

LABEL org.opencontainers.image.source=$REPO_SOURCE
LABEL org.opencontainers.image.description=$DESCRIPTION

COPY $ARTIFACT_PATH /app

RUN chmod +x $ENTRYPOINT

ENTRYPOINT $ENTRYPOINT
CMD []

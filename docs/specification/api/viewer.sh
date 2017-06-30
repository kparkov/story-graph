#!/bin/bash

docker stop story-graph-ui && docker rm story-graph-ui
docker build -f Dockerfile.ui -t story-graph-ui .
docker run --name story-graph-ui -d -p 8080:8080 story-graph-ui
sleep 3
open http://localhost:8080
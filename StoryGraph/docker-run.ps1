docker stop api
docker rm api
docker build -t api .
docker run --name api -d -p 8080:80 api
Start-Sleep -Seconds 2
Start-Process -FilePath Chrome -ArgumentList http://localhost:8080/api/values
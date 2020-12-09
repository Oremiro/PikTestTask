## Tested docker setup
```
Docker version 19.03.13, build 4484c46d9d
docker-compose version 1.27.4, build 40524192
```
## Build
It takes some time, because, both containers are windows based and using same windowsservercore setup
```
docker-compose up -d --build
```

## Important notes about Api.Tests

1. I've added assets/users.tsv inside Debug dir, so probably on your machine tests aren't going to work
2. There are some scripts inside Api.Tests/HttpRequests that you can run for test api
3. My git push was always on all tests had passed
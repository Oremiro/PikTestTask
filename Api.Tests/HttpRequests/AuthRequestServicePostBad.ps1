# 404
Invoke-WebRequest -UseBasicParsing http://localhost:8080/AuthRequestService.svc/auth/post -ContentType "application/json" -Method POST -Body '{ "Username": "user", "Password": "password1"}'
# 404
Invoke-WebRequest -UseBasicParsing http://localhost:8080/AuthRequestService.svc/auth/post -ContentType "application/json" -Method POST -Body '{ "Username": "user1", "Password": "password"}'
# 404
Invoke-WebRequest -UseBasicParsing http://localhost:8080/AuthRequestService.svc/auth/post -ContentType "application/json" -Method POST -Body '{ "Username": "xyz", "Password": "xyz"}'
# 406
Invoke-WebRequest -UseBasicParsing http://localhost:8080/AuthRequestService.svc/auth/post -ContentType "application/json" -Method POST
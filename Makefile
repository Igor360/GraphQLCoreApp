restart:
	docker-compose -f ./Docker/docker-compose.yml down
	docker-compose -f ./Docker/docker-compose.yml up -d --build
	
down:
	docker-compose -f ./Docker/docker-compose.yml down -v

run:
	docker-compose -f ./Docker/docker-compose.yml up -d --build
	
# goToDB:
#     docker-compose -f ./Docker/docker-compose.yml exec database bash
# 
# goToApp:
#     docker-compose -f ./Docker/docker-compose.yml exec app bash

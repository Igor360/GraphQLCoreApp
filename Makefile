restart:
	docker-compose -f ./Docker/docker-compose.yml down
	docker-compose -f ./Docker/docker-compose.yml up -d --build
	
down:
	docker-compose -f ./Docker/docker-compose.yml down

run:
	docker-compose -f ./Docker/docker-compose.yml up -d --build
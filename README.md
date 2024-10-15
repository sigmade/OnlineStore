# OnlineStore

docker network create elastic

docker pull docker.elastic.co/elasticsearch/elasticsearch:8.15.2

wsl -d docker-desktop
	 sysctl -w vm.max_map_count=262144

docker run --name es01 --net elastic -p 9200:9200 -it docker.elastic.co/elasticsearch/elasticsearch:8.15.2

docker cp es01:/usr/share/elasticsearch/config/certs/http_ca.crt .   ???

Google extension: Elasticvue


PUT /products
{
  "mappings": {
    "properties": {
      "id": { "type": "integer" },
      "name": { "type": "text", "analyzer": "russian" },
      "description": { "type": "text", "analyzer": "russian" },
      "price": { "type": "float" }
    }
  }
}
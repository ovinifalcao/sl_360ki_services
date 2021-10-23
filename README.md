# Bem Vindo ao 360KI
360KI é um projeto universitário que tem a premissa de agrupar informações sobre o Clima, Qualidade do Ar e Trânsito, bem como criar uma comunidade de usuários locais que disponibilizem as ocorrências de suas regiões, tais como Batidas de Carro, Enchentes, Desmoronamento ou outros.

## Login

**POST** api/KiLogin?phoneNum=**{NumeroDoTelefone}**&WSP=**{Senha}**

Para realizar login na aplicação estamos utilizando autenticação via JWT, portanto uma vez que a autenticação via Número de telefone e Senha tenha sido feita no sistema, um Token será recebido, este Token tem a duração de 30 minutos, e deve ser usado no cabeçalho de todas as requisições que precisam de autorização.

Retorno:

    {
    "user": string, -- Nome do Usuário
    "userid": int, --Id do Usuário para futuras conferencias
    "token": string –Tokem válido por 30minutos
    }

De acordo com a regra de negócio R.1.0, há informações internas que podem ser consultadas sem a necessidade de login, e informações externas que são de domínio público sobre as quais não pode ser feito qualquer tipo de bloqueio de acesso, por tanto os únicos endpoitns nos quais são realmente necessário adicionar identificação estarão marcados como “Autorizar”.

## Qualidade do Ar
Via AQICN

**GET** api/AqicnAirQualityConsultant/**{latitude}**,**{Longitude}**

A API tem a funcionalidade de devolver a informações do ar mais próximo da localização fornecida. Para o caso onde não se possa receber a latitude e a longitude via GPS utilize: [http://ip-api.com/json/**{IPV6}**](http://ip-api.com/json/%7bIPV6%7d)  para descobrir a localização do usuário.

    {
      "status": "ok", 
      "data": {
        "aqi": 22, -
        "idx": 370,
        "attributions": [
          {
            "url": "http://www.cetesb.sp.gov.br/",
            "name": "CETESB - Companhia Ambiental do Estado de São Paulo",
            "logo": "Brazil-CETESB.png"
          },
          {
            "url": "https://waqi.info/",
            "name": "World Air Quality Index Project",
            "logo": null
          }
        ],
        "city": {
          "geo": [
            -23.65497723,
            -46.709998382
          ],
          "name": "Santo Amaro, São Paulo, Brazil",
          "url": "https://aqicn.org/city/brazil/sao-paulo/santo-amaro"
        },
        "dominentpol": "pm10",
        "iaqi": {
          "co": null,
          "h": {
            "v": 72
          },
          "no2": null,
          "o3": null,
          "p": {
            "v": 1016
          },
          "pm10": {
            "v": 22
          },
          "pm25": null,
          "t": {
            "v": 19
          },
          "w": {
            "v": 3
          },
          "wg": null
        },
        "time": {
          "s": "2021-10-23 09:00:00",
          "tz": "-03:00",
          "v": 1634979600,
          "iso": "2021-10-23T09:00:00-03:00"
        },
        "forecast": {
          "daily": {
            "o3": [
              {
                "avg": 4,
                "day": "2021-10-21",
                "max": 14,
                "min": 1
              }
        },
        "debug": {
          "sync": "2021-10-23T21:15:23+09:00"
        }
      }
    }

## Previsão do Tempo

Via HG Weather

**GET** /api/HgWeatherConsutant

Este endpoint está configurado internamente “hardcoded” para receber apena a previsão do tempo para a cidade de São Paulo, por conta disso, não há parâmetros para serem passados.

    {
       "by":"woeid",
       "valid_key":false,
       "results":{
          "temp":23,
          "date":"23/10/2021",
          "time":"10:18",
          "condition_code":"27",
          "description":"Tempo limpo",
          "currently":"dia",
          "cid":"",
          "city":"São Paulo, SP",
          "img_id":"27",
          "humidity":67,
          "wind_speedy":"0.45 km/h",
          "sunrise":"05:26 am",
          "sunset":"06:14 pm",
          "condition_slug":"clear_day",
          "city_name":"São Paulo",
          "forecast":[
             {
                "date":"23/10",
                "weekday":"Sáb",
                "max":30,
                "min":14,
                "description":"Tempo limpo",
                "condition":"clear_day"
             }
          ]
       },
       "execution_time":0,
       "from_cache":true
    }

## Cadastrar Usuário

**Autorizar**
**POST** /api/BsUserResgistereds

Este método irá cadastrar um usuário no banco de dados com as informações de Nome, Data de Nascimento, Zona da Cidade {1 - Norte, 2 - Leste, 3 - Sul, 4 - Oeste}, numero de telefone (9XXXXXXXX) e Senha.

**Body**:

    {    
        "bsUserResgistered": {    
    	    "name": "string",    
    	    "birthDate": "2021-10-23T13:20:59.842Z",    
    	    "cityZoneId": 0    
        },    
	    "opUserService": {    
	        "phoneNum": 0,    
	        "wsp": "string"
        }
    }

## Ocorrências dos Usuários

**GET** /api/BsOcurrenceReports
Recebe todas as ocorrências registradas no Banco de dados.

**GET** /api/BsOcurrenceReports/**{IdDaOcorrencia}**
Recebe uma ocorrência especifica baseada no ID da mesma.

**Autorizar**
**POST** /api/BsOcurrenceReports
Cadastra uma nova Ocorrência
Body:

    {
	    "usrgdOwnerFk": int, --Id do Usuário, pode ser recebido na requisição do login
	    "title": string, --Título da ocorrência
	    "kindId": Int, --Tipo da Ocorrência (Ver /api/KdOcurrences)
	    "place": string, --Endereço da ocorrência
	    "cityZoneId": int, --Zona da Cidade (Ver /api/KdCityZones)
	    "moment": string - Datatime
    }

**Autorizar**
**DELETE** /api/BsOcurrenceReports/**{IdDaOcorrencia}**,**{IdDoUsário}**
Deleta uma Ocorrência previamente reportada, internamente verifica se quem postou foi o mesmo usuário que está tentando excluir.

## Respostas das Ocorrências dos Usuários

**Autorizar**
**POST** /api​/BsOcurrencesReplies
Insere uma resposta para aquela ocorrência.

Body

    {
    	"usrgdFk": int, --Id do Usuário
    	"kindId": int, --Qual o tipo de resposta (ver /api/KdOcurrencesReplies)
    	"moment": "2021-10-23T13:37:12.610Z"
    }

**Autorizar**
**PUT** /api/BsOcurrencesReplies/**{idDaOcorrencia}**
Altera a resposta previamente dada a uma ocorrência.

Body

    {
	    "usrgdFk": int, --Id do Usuário
	    "kindId": int, --Qual o tipo de resposta (ver /api/KdOcurrencesReplies)
	    "moment": "2021-10-23T13:37:12.610Z"
    }

**Autorizar**
**DELETE** /api/BsOcurrencesReplies/**{idDaOcorrencia}**
Remove uma resposta previamente dada a uma ocorrência.

## Informativos

**GET** /api/KdOcurrences
Recebe todas os tipos de ocorrência gravados no banco, com Id do Tipo e o Tipo descrito.

**GET** /api/ KdOcurrences /**{Id}**
Consulta a descrição de um tipo de ocorrência baseado no seu ID.

**GET** /api/KdOcurrencesReplies
Recebe todas os tipos de respostas à ocorrencias gravados no banco, com Id do Tipo e o Tipo descrito.

**GET** /api/KdOcurrencesReplies/**{Id}**
Consulta a descrição de um tipo de resposta baseado no seu ID.

**GET** /api/KdCityZones
Recebe todas as zonas a cidade cadastradas no banco de dados.

**GET** /api/KdCityZones /**{Id}**
Consulta uma zona da cidade específica baseado em seu ID.
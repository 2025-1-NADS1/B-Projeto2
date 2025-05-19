
# Hardware

## Sistema de Coleta e Envio de Dados para a Web

### 1. Descrição do Hardware

Este sistema utiliza um hardware (como Arduino, ESP32, Raspberry Pi ou outro dispositivo embarcado) para coletar dados de sensores ou outros dispositivos conectados. O hardware é responsável por:

* Capturar dados relevantes (exemplo: temperatura, umidade, pressão, luminosidade).
* Processar esses dados para envio.
* Transmitir os dados para um servidor web via rede (Wi-Fi, Ethernet, etc.).

### 2. Dados Coletados

Os dados coletados podem variar conforme o hardware e sensores utilizados. Exemplos típicos:

| Tipo de Dado | Descrição                 |
| ------------ | ------------------------- |
| Temperatura  | Valor em graus Celsius    |
| Umidade      | Percentual de umidade (%) |
| Luminosidade | Nível de luz ambiente     |
| Status       | Estado do dispositivo     |

### 3. Método de Comunicação

Para enviar os dados ao servidor, o sistema utiliza o protocolo HTTP via requisições POST para uma API REST. A conexão pode ser configurada para usar HTTPS para garantir a segurança.

Exemplo do fluxo:

1. O hardware coleta o dado.
2. Constrói um pacote JSON com as informações.
3. Envia a requisição POST para o endpoint do servidor.
4. Aguarda a resposta para confirmar o recebimento.

### 4. Código Principal

Segue um exemplo básico de código (pseudocódigo / Arduino C++) para envio dos dados via HTTP:

```cpp
#include <WiFi.h>
#include <HTTPClient.h>

// Configurações Wi-Fi
const char* ssid = "SEU_SSID";
const char* password = "SUA_SENHA";

// Endpoint do servidor
const char* serverUrl = "http://seu-servidor.com/api/dados";

void setup() {
  Serial.begin(115200);
  WiFi.begin(ssid, password);

  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }
  Serial.println("WiFi conectado");
}

void loop() {
  if (WiFi.status() == WL_CONNECTED) {
    HTTPClient http;
    http.begin(serverUrl);
    http.addHeader("Content-Type", "application/json");

    // Exemplo de dados em JSON
    String jsonData = "{\"temperatura\":25.5,\"umidade\":60}";

    int httpResponseCode = http.POST(jsonData);

    if (httpResponseCode > 0) {
      String response = http.getString();
      Serial.println("Resposta do servidor: " + response);
    } else {
      Serial.println("Erro no envio: " + String(httpResponseCode));
    }

    http.end();
  } else {
    Serial.println("WiFi desconectado");
  }

  delay(60000); // Espera 60 segundos para nova leitura/envio
}
```

### 5. Instruções para Compilação e Execução

* Instale a IDE Arduino (ou ambiente compatível).
* Instale as bibliotecas WiFi e HTTPClient.
* Configure o SSID e senha da sua rede no código.
* Atualize o endereço do servidor para o endpoint correto.
* Compile e faça o upload do código para o hardware.
* Monitore a saída serial para verificar o status da conexão e envio.

### 6. Observações

* Ajuste o intervalo de envio conforme a necessidade do seu projeto.
* Considere implementar mecanismos para reconectar Wi-Fi automaticamente.
* Caso utilize outro protocolo (MQTT, WebSocket), ajuste o código e documentação.
* Garanta a segurança na transmissão dos dados, especialmente em redes públicas.

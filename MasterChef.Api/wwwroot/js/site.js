<script>
    function buscarDados() {
        console.log("Teste")
        // criar objeto XMLHttpRequest
        var xhr = new XMLHttpRequest();

    // configurar a solicitação
    xhr.open("GET", "/Controller/Get", true);
    xhr.setRequestHeader("Content-Type", "application/json");

    // configurar o retorno
    xhr.onreadystatechange = function () {
            if (this.readyState === XMLHttpRequest.DONE && this.status === 200) {
        document.getElementById("resultado").innerHTML = this.responseText;
            }
        };

    // enviar a solicitação
    xhr.send();
    }

    function adicionarDados() {
        // criar objeto XMLHttpRequest
        var xhr = new XMLHttpRequest();

    // configurar a solicitação
    xhr.open("POST", "/Controller/Post", true);
    xhr.setRequestHeader("Content-Type", "application/json");

    // configurar os dados a serem enviados
    var dados = {nome: "Receita 1", descricao: "Uma deliciosa receita" };

    // configurar o retorno
    xhr.onreadystatechange = function () {
            if (this.readyState === XMLHttpRequest.DONE && this.status === 200) {
        alert("Dados adicionados com sucesso!");
            }
        };

    // enviar a solicitação
    xhr.send(JSON.stringify(dados));
    }
    
    function teste(){
        console.log("Teste")
    };
</script>

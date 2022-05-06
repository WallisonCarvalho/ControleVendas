<script src="https://www.gstatic.com/dialogflow-console/fast/messenger/bootstrap.js?v=1"></script>
<df-messenger
  intent="WELCOME"
  chat-title="Primeiro"
  agent-id="d11622e7-ccc6-402c-a2fa-70bd60bae0eb"
  language-code="pt-br"
></df-messenger>




/*------------------------------------------Gráfico de Barra----------------------------------------------*/

let ctx = document.getElementById('myChart').getContext('2d');
let myChart = new Chart(ctx, {
    type: 'line',
    data: {
        labels: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
        datasets: [{
            label: 'ùltimos 12 meses',
            data: [12, 19, 3, 5, 2, 3, 12, 19, 3, 5, 2, 3],
            backgroundColor: [
                'rgba(257, 99, 132, 0.2)',
            ],
            borderColor: [
                'rgba(255, 99, 132, 1)',
            ],
            borderWidth: 1
        }]
    },
    options: {
        scales: {
            y: {
                beginAtZero: true
            }
        }
    }
});
/*------------------------------------------Gráfico de linha----------------------------------------------*/

let bar = document.getElementById('barra').getContext('2d');
let barra = new Chart(bar, {
    type: 'bar',
    data: {
        labels: ['01', '02', '03', '04', '05', '06', '01', '02', '03', '04', '05', '06', '01', '02', '03', '04', '05', '06', '01', '02', '03',
            '04', '05', '06', '01', '02', '03', '04', '05', '06', '01', '02', '03', '04', '05', '06',],
        datasets: [{
            label: 'Mês atual',
            data: [12, 19, 3, 5, 2, 3],
            backgroundColor: [
                'rgba(255, 99, 132, 0.2)',
            ],
            borderColor: [
                'rgba(255, 99, 132, 1)',
            ],
            borderWidth: 1
        }]
    },
    options: {
        scales: {
            y: {
                beginAtZero: true
            }
        }
    }
});
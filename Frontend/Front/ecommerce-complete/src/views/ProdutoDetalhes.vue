<template>
  <main class="max-w-6xl mx-auto px-4 py-8 space-y-12">
    <!-- Detalhes do produto (imagem à esquerda, texto à direita) -->
    <div class="flex flex-col lg:flex-row gap-10">
      <!-- Coluna da Imagem e Carrossel -->
      <div class="flex flex-col items-center lg:items-start w-full lg:w-1/2">
        <!-- Imagem principal -->
        <img
          :src="imagemPrincipal"
          alt="Imagem principal"
          class="w-full h-[400px] object-contain rounded-lg mb-4"
        />

        <!-- Mini carrossel -->
        <div class="flex gap-2 overflow-x-auto">
          <img
            v-for="(foto, index) in produto?.fotosDetalhadas"
            :key="index"
            :src="foto"
            alt="Detalhe"
            class="w-20 h-20 object-contain rounded cursor-pointer border hover:border-blue-600 transition"
            @click="imagemPrincipal = foto"
          />
        </div>
      </div>

      <!-- Coluna de detalhes -->
      <div class="flex flex-col justify-center w-full lg:w-1/2 text-center lg:text-left">
        <h1 class="text-3xl font-bold text-blue-700 mb-2">{{ produto?.name }}</h1>

        <div
          v-if="produto?.avaliacoes"
          class="flex items-center gap-2 mb-2 justify-center lg:justify-start"
        >
          <div class="flex text-yellow-400 text-xl">
            <span v-for="n in estrelas.cheias" :key="'full' + n">★</span>
            <span v-if="estrelas.meia">⯪</span>
            <span v-for="n in estrelas.vazias" :key="'empty' + n" class="text-gray-300"
              >★</span
            >
          </div>
          <span class="text-sm text-gray-600">
            {{ produto.avaliacoes.nota.toFixed(1) }} ({{ produto.avaliacoes.total }}
            avaliações)
          </span>
        </div>

        <p class="text-gray-600 mb-4">{{ produto?.description }}</p>
        <span class="text-green-600 font-bold text-xl mb-4">R$ {{ produto?.price.toFixed(2) }}</span>

        <!-- Resumo IA (resumo definitivo gerado pela IA) -->
        <section
          v-if="resumoIA"
          class="bg-blue-50 border border-blue-300 p-4 rounded-lg mb-6 text-blue-900"
        >
          <h3 class="font-semibold mb-2">Resumo de avaliações por IA</h3>
          <p class="italic">"{{ resumoIA }}"</p>
        </section>

        <button
          class="w-full lg:w-auto bg-gradient-to-r from-blue-600 to-green-500 text-white py-2 px-6 rounded-full hover:opacity-90"
        >
          Adicionar ao Carrinho
        </button>
      </div>
    </div>

      <!-- Produtos recomendados -->
      <section>
        <h2 class="text-2xl font-semibold text-blue-700 mb-6">Produtos Recomendados</h2>
        <div class="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-6">
      <router-link
    v-for="item in produtosRecomendados"
    :key="item.id"
    :to="`/produto/${item.id}`"
    class="block bg-white rounded-2xl shadow hover:shadow-md transition p-4 text-center hover:scale-[1.02] duration-200"
  >
    <img
      :src="item.image"
      alt="Recomendado"
      class="w-full h-40 object-contain rounded-lg mb-3"
    />
    <h3 class="text-lg font-semibold text-blue-700">{{ item.name }}</h3>
    <p class="text-sm text-gray-500 mb-2">{{ item.description }}</p>
    <span class="text-green-600 font-bold text-md">R$ {{ item.price.toFixed(2) }}</span>
  </router-link>

        </div>
  
    </section>

    <!-- Formulário de avaliação -->
    <section class="max-w-lg mx-auto bg-white p-6 rounded-lg shadow-md">
      <h2 class="text-2xl font-semibold text-blue-700 mb-4 text-center">Deixe sua avaliação</h2>

      <form @submit.prevent="enviarAvaliacao" class="space-y-4">
        <div class="flex justify-center gap-1 text-3xl cursor-pointer select-none">
          <span
            v-for="star in 5"
            :key="star"
            @click="avaliacaoNota = star"
            @mouseover="hoverNota = star"
            @mouseleave="hoverNota = 0"
            :class="{
              'text-yellow-400': star <= (hoverNota || avaliacaoNota),
              'text-gray-300': star > (hoverNota || avaliacaoNota),
            }"
            >★</span
          >
        </div>

        <textarea
          v-model="avaliacaoComentario"
          rows="4"
          placeholder="Escreva seu comentário aqui..."
          class="w-full border border-gray-300 rounded-md p-2 resize-none focus:outline-blue-500"
          required
        ></textarea>

        <button
          type="submit"
          class="w-full bg-gradient-to-r from-blue-600 to-green-500 text-white py-2 px-6 rounded-full hover:opacity-90"
        >
          Enviar Avaliação
        </button>
      </form>
    </section>
  </main>
</template>

<script setup>
import { useRoute } from 'vue-router'
import { ref, onMounted } from 'vue'

const route = useRoute()
const produto = ref(null)
const imagemPrincipal = ref('')
const estrelas = ref({ cheias: 0, meia: false, vazias: 5 })

const avaliacaoNota = ref(0)
const avaliacaoComentario = ref('')
const hoverNota = ref(0)

// Estado para resumo definitivo gerado pela IA
const resumoIA = ref('')

// Simulação de produtos
const produtos = [
  {
    id: 1,
    name: 'Fone Bluetooth',
    description: 'Qualidade premium com cancelamento de ruído.',
    price: 149.99,
    image: 'https://m.media-amazon.com/images/I/41uPe7wmo-L.__AC_SX300_SY300_QL70_ML2_.jpg',
    fotosDetalhadas: [
      'https://m.media-amazon.com/images/I/41uPe7wmo-L.__AC_SX300_SY300_QL70_ML2_.jpg',
      'https://m.media-amazon.com/images/I/51zNiTmy6dL._AC_SX679_.jpg',
      'https://m.media-amazon.com/images/I/51woSHdQ+sL._AC_SX679_.jpg',
      'https://m.media-amazon.com/images/I/51CjRbbr5oL._AC_SX679_.jpg',
      'https://m.media-amazon.com/images/I/51woSHdQ+sL._AC_SX679_.jpg',
      'https://m.media-amazon.com/images/I/51Wzqkhd0kL._AC_SX679_.jpg',

    ],
    avaliacoes: {
      nota: 4.5,
      total: 23,
    },
  },
  {
    id: 2,
    name: 'Diários de um robô assassino: Alerta Vermelho',
    description: 'Um.',
    price: 29.90,
    image: 'https://m.media-amazon.com/images/I/71qsUmb9ZbL._SY425_.jpg',
    fotosDetalhadas: [
      'https://m.media-amazon.com/images/I/71qsUmb9ZbL._SY425_.jpg',
      'https://m.media-amazon.com/images/I/71Fm+YuSYML._SY425_.jpg',
      'https://m.media-amazon.com/images/I/611M1An8B4L._SY425_.jpg',
      'https://m.media-amazon.com/images/I/81Wc-U+hTXL._SL1500_.jpg',
      'https://m.media-amazon.com/images/I/7104C62zyHL._SL1500_.jpg',
      'https://m.media-amazon.com/images/I/71gQtNdfS+L._SL1500_.jpg',
    ],
    avaliacoes: {
      nota: 4,
      total: 12,
    },
  },
  {
    id: 3,
    name: 'Cafeteira Elétrica',
    description: 'Design moderno e café pronto em minutos.',
    price: 199.9,
    image: 'https://m.media-amazon.com/images/I/41WW04HfTnL._AC_SX679_.jpg',
    fotosDetalhadas: [
      'https://m.media-amazon.com/images/I/41WW04HfTnL._AC_SX679_.jpg',
      'https://m.media-amazon.com/images/I/41rWhQN3O1L._AC_SX679_.jpg',
      'https://m.media-amazon.com/images/I/41OV3EbcYYL._AC_SX679_.jpg',
      'https://m.media-amazon.com/images/I/51AqZ-IerDL._AC_SX679_.jpg',
      'https://m.media-amazon.com/images/I/51mwNwgqy1L._AC_SX679_.jpg', 
    ],
    avaliacoes: {
      nota: 3.5,
      total: 8,
    },
  },

    {
    id: 4,
    name: ' Notebook Slim',
    description: 'Leve rápido e perfeito para o dia a dia.',
    price: 2499.99,
    image: 'https://m.media-amazon.com/images/I/51lGW2nP9qL.__AC_SX300_SY300_QL70_ML2_.jpg',
    fotosDetalhadas: [
      'https://m.media-amazon.com/images/I/51lGW2nP9qL.__AC_SX300_SY300_QL70_ML2_.jpg',
      'https://m.media-amazon.com/images/I/41jfXTWkWKL._AC_SY450_.jpg',
      'https://m.media-amazon.com/images/I/41esffzwrBL._AC_SY450_.jpg',
      'https://m.media-amazon.com/images/I/61HZsppN3kL._AC_SY450_.jpg',
      'https://m.media-amazon.com/images/I/61ejWPc9eKL._AC_SY450_.jpg', 
      'https://m.media-amazon.com/images/I/712DiCp2KHL._AC_SY450_.jpg',
    ],
    avaliacoes: {
      nota: 4.5,
      total: 8,
    },
  },
]

// Função para calcular estrelas
function getEstrelas(nota) {
  const cheias = Math.floor(nota)
  const meia = nota % 1 >= 0.5
  const vazias = 5 - cheias - (meia ? 1 : 0)
  return { cheias, meia, vazias }
}

// Simulação de busca do resumo IA
async function fetchResumoIA(produtoId) {
  await new Promise((resolve) => setTimeout(resolve, 300))

  const resumosSimulados = {
    1: 'Som de alta qualidade com cancelamento eficaz de ruído. Bateria duradoura e design confortável para uso prolongado.',
    2: 'Livro inspirador e informativo, ideal para profissionais da tecnologia, com capítulos bem organizados.',
    3: 'Cafeteira prática, rápida e com design elegante, perfeita para quem quer café saboroso sem complicação.',
  }

  resumoIA.value = resumosSimulados[produtoId] || ''
}

onMounted(async () => {
  const id = Number(route.params.id)
  const encontrado = produtos.find((p) => p.id === id)
  if (encontrado) {
    produto.value = encontrado
    imagemPrincipal.value = encontrado.image
    estrelas.value = getEstrelas(encontrado.avaliacoes?.nota || 0)
    await fetchResumoIA(encontrado.id)
  }
})

// Produtos recomendados (exceto o atual)
const produtosRecomendados = produtos.filter(
  (p) => p.id !== Number(route.params.id),
)

// Enviar avaliação (simulação)
function enviarAvaliacao() {
  if (avaliacaoNota.value === 0) {
    alert('Por favor, selecione uma nota de estrelas.')
    return
  }
  console.log('Avaliação enviada:', {
    produtoId: produto.value.id,
    nota: avaliacaoNota.value,
    comentario: avaliacaoComentario.value,
  })
  alert('Obrigado pela sua avaliação!')

  avaliacaoNota.value = 0
  avaliacaoComentario.value = ''
  hoverNota.value = 0
}
</script>

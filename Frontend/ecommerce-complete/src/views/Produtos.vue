<template>
  <main class="max-w-7xl mx-auto px-4 py-8">
    <h1 class="text-2xl font-bold text-blue-700 mb-6">Todos os Produtos</h1>

    <div class="flex gap-6">
      <!-- Filtros -->
      <aside class="w-64 space-y-4 hidden md:block">
        <div>
          <h2 class="font-semibold text-green-600 mb-2">Categorias</h2>
          <ul class="space-y-1 text-gray-700">
            <li
              v-for="categoria in categorias"
              :key="categoria"
              class="cursor-pointer hover:text-blue-700"
              @click="categoriaSelecionada = categoria"
              :class="categoriaSelecionada === categoria ? 'text-blue-700 font-semibold' : ''"
            >
              {{ categoria }}
            </li>
            <li
              class="cursor-pointer text-sm text-gray-500 hover:text-blue-700 mt-2"
              @click="categoriaSelecionada = null"
            >
              Limpar filtro
            </li>
          </ul>
        </div>

        <div>
          <h2 class="font-semibold text-green-600 mb-2">Preço (até R$ {{ precoMaximo }})</h2>
          <input
            type="range"
            min="0"
            max="3000"
            v-model="precoMaximo"
            class="w-full accent-blue-600"
          />
        </div>
      </aside>

      <!-- Lista de Produtos -->
      <section class="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-6 flex-1">
        <div
          v-for="product in produtosFiltrados"
          :key="product.id"
          class="bg-white rounded-2xl shadow hover:shadow-lg transition p-4 flex flex-col items-center text-center"
        >
          <!-- AQUI: wrapper com tamanho fixo -->
          <div class="w-full h-48 overflow-hidden rounded-lg mb-4">
            <img
              :src="product.image"
              alt="Produto"
              class="w-full h-full object-contain"
            />
          </div>

          <h3 class="text-lg font-semibold text-blue-700">{{ product.name }}</h3>
          <p class="text-gray-600 text-sm mt-1">{{ product.description }}</p>
          <span class="text-green-600 font-bold text-md mt-2">R$ {{ product.price.toFixed(2) }}</span>
          <router-link
            :to="`/produto/${product.id}`"
            class="mt-4 bg-gradient-to-r from-blue-600 to-green-500 text-white py-1 px-4 rounded-full hover:opacity-90"
          >
            Ver Detalhes
          </router-link>
        </div>
      </section>
    </div>
  </main>
</template>

<script setup>
import { ref, computed } from 'vue'

// Dados simulados
const products = [
  { id: 1, name: 'Fone Bluetooth', category: 'Eletrônicos', description: 'Qualidade premium com cancelamento de ruído.', price: 149.99, image: 'https://m.media-amazon.com/images/I/41uPe7wmo-L.__AC_SX300_SY300_QL70_ML2_.jpg' },
  { id: 2, name: 'Diários de um Robô assassino: Alerta Vermelho', category: 'Livros', description: 'Um.', price: 29.90, image: 'https://m.media-amazon.com/images/I/71qsUmb9ZbL._SY425_.jpg' },
  { id: 3, name: 'Cafeteira Elétrica', category: 'Casa', description: 'Design moderno e café pronto em minutos.', price: 199.90, image: 'https://m.media-amazon.com/images/I/41WW04HfTnL._AC_SX679_.jpg' },
  { id: 4, name: 'Notebook Slim', category: 'Eletrônicos', description: 'Leve, rápido e perfeito para o dia a dia.', price: 2499.99, image: 'https://m.media-amazon.com/images/I/51lGW2nP9qL.__AC_SX300_SY300_QL70_ML2_.jpg' },
  { id: 5, name: 'Luminária LED Inteligente', category: 'Casa', description: 'Controle por voz e ajuste de intensidade.', price: 89.90, image: 'https://m.media-amazon.com/images/I/51vwyDvZqoL.__AC_SX300_SY300_QL70_ML2_.jpg' },
  { id: 6, name: 'Aspirador Robô', category: 'Casa', description: 'Limpeza automática e silenciosa.', price: 599.99, image: 'https://m.media-amazon.com/images/I/81w-AyhZt-L.__AC_SX300_SY300_QL70_ML2_.jpg' }
]

// Filtros reativos
const categorias = ['Eletrônicos', 'Livros', 'Casa']
const categoriaSelecionada = ref(null)
const precoMaximo = ref(3000)

// Filtro computado
const produtosFiltrados = computed(() => {
  return products.filter(p => {
    const porCategoria = categoriaSelecionada.value ? p.category === categoriaSelecionada.value : true
    const porPreco = p.price <= precoMaximo.value
    return porCategoria && porPreco
  })
})
</script>


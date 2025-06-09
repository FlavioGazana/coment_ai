<template>
  <main class="max-w-md mx-auto mt-12 p-6 bg-white rounded-lg shadow-md">
    <h2 class="text-2xl font-semibold text-blue-700 mb-6 text-center">Cadastro de Produto</h2>
    
    <form @submit.prevent="cadastrarProduto" class="space-y-4">
      <div>
        <label for="name" class="block font-medium text-gray-700 mb-1">Nome do Produto</label>
        <input
          id="name"
          v-model="produto.name"
          type="text"
          placeholder="Ex: Fone Bluetooth"
          class="w-full border border-gray-300 rounded-md p-2 focus:outline-blue-500"
          required
        />
      </div>
      
      <div>
        <label for="description" class="block font-medium text-gray-700 mb-1">Descrição</label>
        <textarea
          id="description"
          v-model="produto.description"
          rows="3"
          placeholder="Descrição breve do produto"
          class="w-full border border-gray-300 rounded-md p-2 resize-none focus:outline-blue-500"
          required
        ></textarea>
      </div>
      
      <div>
        <label for="price" class="block font-medium text-gray-700 mb-1">Preço (R$)</label>
        <input
          id="price"
          v-model.number="produto.price"
          type="number"
          min="0"
          step="0.01"
          placeholder="Ex: 149.99"
          class="w-full border border-gray-300 rounded-md p-2 focus:outline-blue-500"
          required
        />
      </div>

      <div>
        <label for="image" class="block font-medium text-gray-700 mb-1">URL da Imagem</label>
        <input
          id="image"
          v-model="produto.image"
          type="url"
          placeholder="https://exemplo.com/imagem.jpg"
          class="w-full border border-gray-300 rounded-md p-2 focus:outline-blue-500"
          required
        />
      </div>

      <button
        type="submit"
        class="w-full bg-gradient-to-r from-blue-600 to-green-500 text-white py-2 rounded-full hover:opacity-90 transition"
      >
        Cadastrar Produto
      </button>
    </form>
  </main>
</template>

<script setup>
import { reactive } from 'vue'

const produto = reactive({
  name: '',
  description: '',
  price: null,
  image: ''
})

function cadastrarProduto() {
  if (!produto.name || !produto.description || produto.price === null || !produto.image) {
    alert('Por favor, preencha todos os campos corretamente.')
    return
  }

  console.log('Produto cadastrado:', { ...produto })

  alert(`Produto "${produto.name}" cadastrado com sucesso!`)

  produto.name = ''
  produto.description = ''
  produto.price = null
  produto.image = ''
}
</script>


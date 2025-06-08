<template>
  <main class="min-h-screen flex items-center justify-center bg-gradient-to-r from-green-500 to-blue-600 p-6">
    <div class="bg-white rounded-xl shadow-lg w-full max-w-md p-8 animate-fade-in">
      <h1 class="text-3xl font-bold text-green-600 text-center mb-6">Cadastro</h1>

      <form @submit.prevent="handleCadastro" class="space-y-5">
        <input
          type="text"
          v-model="nome"
          placeholder="Nome completo"
          required
          class="w-full px-4 py-3 rounded-md border border-gray-300 focus:outline-none focus:ring-2 focus:ring-green-600"
        />
        <input
          type="email"
          v-model="email"
          placeholder="Email"
          required
          class="w-full px-4 py-3 rounded-md border border-gray-300 focus:outline-none focus:ring-2 focus:ring-blue-600"
        />
        <input
          type="password"
          v-model="senha"
          placeholder="Senha"
          required
          class="w-full px-4 py-3 rounded-md border border-gray-300 focus:outline-none focus:ring-2 focus:ring-green-500"
        />

        <button
          type="submit"
          class="w-full py-3 bg-gradient-to-r from-green-500 to-blue-600 text-white font-semibold rounded-md hover:opacity-90 transform transition active:scale-95"
        >
          Cadastrar
        </button>
      </form>

      <p class="text-center text-sm text-gray-600 mt-4">
        Já tem uma conta?
        <router-link to="/login" class="text-blue-700 underline hover:text-green-600">
          Faça login
        </router-link>
      </p>
    </div>
  </main>
</template>

<script setup>
import { ref } from 'vue'
import { useRouter } from 'vue-router'

const router = useRouter()
const nome = ref('')
const email = ref('')
const senha = ref('')

function handleCadastro() {
  if (!nome.value || !email.value || !senha.value) {
    alert('Preencha todos os campos!')
    return
  }

  alert(`Cadastro realizado com sucesso, ${nome.value}!`)
  router.push('/login')
}
</script>

<style scoped>
@keyframes fade-in {
  from { opacity: 0; transform: translateY(20px); }
  to { opacity: 1; transform: translateY(0); }
}

.animate-fade-in {
  animation: fade-in 0.6s ease-out;
}
</style>

<template>
  <main
    class="min-h-screen flex flex-col justify-center items-center bg-gradient-to-r from-blue-600 to-green-500 p-6"
  >
    <div
      class="bg-white rounded-lg shadow-lg max-w-md w-full p-8 space-y-6"
    >
      <h1 class="text-3xl font-bold text-blue-700 text-center">Login</h1>

      <form @submit.prevent="handleLogin" class="space-y-5">
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
          class="w-full py-3 bg-gradient-to-r from-blue-600 to-green-500 text-white font-semibold rounded-md hover:opacity-90 transform transition active:scale-95"
        >
          Entrar
        </button>
      </form>

      <p class="text-center text-sm text-gray-600">
        Não tem conta?
        <router-link to="/cadastro" class="text-blue-700 underline hover:text-green-600"
          >Cadastre-se</router-link
        >
      </p>
    </div>
  </main>
</template>

<script setup>
import { ref } from 'vue'
import { useRouter } from 'vue-router'

const router = useRouter()
const email = ref('')
const senha = ref('')

function handleLogin() {
  if (!email.value || !senha.value) {
    alert('Preencha todos os campos!')
    return
  }

  // Simula autenticação
  alert(`Bem-vindo(a), ${email.value}!`)
  router.push('/')
}
</script>

<template>
  <header class="bg-gradient-to-r from-blue-600 to-green-500 text-white shadow">
    <div class="max-w-4xl mx-auto px-4 py-3 flex items-center justify-between">
      <!-- Logo -->
      <div class="flex items-center space-x-2">
        <img
          src="@/assets/Logo.png"
          alt="Minha Loja"
          class="h-70 w-40"
        />
        <span class="text-xl font-bold"></span>
      </div>

      <!-- Barra de Pesquisa -->
      <div class="flex-1 mx-6">
        <div class="relative">
          <span class="absolute inset-y-0 left-3 flex items-center text-gray-400">
            <svg xmlns="http://www.w3.org/2000/svg" class="h-5 w-5" fill="none"
                 viewBox="0 0 24 24" stroke="currentColor">
              <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                    d="M21 21l-4.35-4.35M17 10a7 7 0 11-14 0 7 7 0 0114 0z" />
            </svg>
          </span>
          <input
            type="text"
            placeholder="Buscar produtos..."
            class="w-full py-2 pl-10 pr-4 rounded-full shadow text-gray-800 placeholder-gray-400"
          />
        </div>
      </div>
    </div>
          <div class="max-w-6xl mx-auto px-4 py-2 flex space-x-8 justify-center text-sm font-medium">
        <RouterLink to="/" class="hover:underline">Início</RouterLink>
        <RouterLink to="/produtos" class="hover:underline">Produtos</RouterLink>
        <RouterLink to="/login" class="hover:underline">Entrar</RouterLink>
    <router-link to="/cadastro-produto">Cadastrar Produto</router-link>
      </div> 

    <!-- Menu de navegação -->
    <nav class="bg-gradient-to-r from-blue-700 to-green-600 text-white">

    </nav>
  </header>
</template>





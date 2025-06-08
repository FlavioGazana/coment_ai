<template>
  <div class="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 gap-6">
    <div
      v-for="(image, index) in images"
      :key="index"
      class="bg-white border border-gray-200 rounded-2xl shadow transition hover:shadow-lg hover:shadow-blue-200 p-4 text-center"
    >
      <!-- Contêiner fixo para a imagem -->
      <div class="w-[300px] h-[200px] mx-auto flex items-center justify-center">
        <img
          :src="image"
          alt="Produto"
          class="max-w-full max-h-full object-contain"
        />
      </div>
    </div>
  </div>
</template>

<script setup>
defineProps({
  images: Array
})
</script>


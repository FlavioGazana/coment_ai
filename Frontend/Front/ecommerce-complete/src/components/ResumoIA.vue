<template>
  <div class="p-4 bg-white rounded-xl shadow">
    <h3 class="font-bold mb-2">Resumo IA</h3>
    <p>{{ summary }}</p>
  </div>
</template>
<script setup>
import { ref, onMounted } from 'vue'
const summary = ref('Analisando avaliações...')
onMounted(() => {
  setTimeout(() => summary.value = 'Resumo gerado pela IA: avaliações positivas destacam qualidade e durabilidade.')
}, 1000)
</script>

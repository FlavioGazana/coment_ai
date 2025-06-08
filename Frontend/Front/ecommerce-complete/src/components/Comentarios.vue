<template>
  <div class="mt-4">
    <h3 class="font-bold mb-2">Comentários</h3>
    <div v-for="(c, i) in comments" :key="i" class="p-2 bg-gray-50 rounded mb-2">
      {{ c }}
    </div>
    <input v-model="newComment" placeholder="Escreva um comentário" class="w-full p-2 border rounded"/>
    <button @click="addComment" class="mt-2 bg-blue-600 text-white px-4 py-2 rounded">Enviar</button>
  </div>
</template>
<script setup>
import { ref } from 'vue'
const comments = ref(['Ótimo produto!', 'Muito bom custo-benefício.'])
const newComment = ref('')
function addComment() {
  if(newComment.value.trim()) {
    comments.value.push(newComment.value.trim())
    newComment.value = ''
  }
}
</script>

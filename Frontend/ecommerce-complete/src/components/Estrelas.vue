<template>
  <div class="flex gap-1">
    <span v-for="n in 5" :key="n" @click="rate(n)">
      ★
    </span>
  </div>
</template>
<script setup>
import { defineEmits } from 'vue'
const emit = defineEmits(['update:rating'])
function rate(n) {
  emit('update:rating', n)
}
</script>

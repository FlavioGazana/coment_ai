<template>
  <!-- Carrossel de promoções -->
  <section class="bg-white py-8">
    <div class="max-w-6xl mx-auto relative overflow-hidden rounded-xl shadow-lg h-[303px]">
      <div
        class="flex transition-transform duration-700 ease-in-out h-full"
        :style="{ transform: `translateX(-${currentIndex * 100}%)` }"
      >
        <div
          v-for="(promo, index) in promos"
          :key="index"
          class="w-full flex-shrink-0"
        >
          <img
            :src="promo"
            alt="Promoção"
            class="w-full h-[303px] object-cover"
          />
        </div>
      </div>
    </div>
  </section>

  <!-- Seções de produtos -->
  <section class="bg-white py-10">
    <div class="max-w-6xl mx-auto space-y-12">
      <div>
        <h2 class="text-2xl font-bold text-blue-700 mb-4">Produtos Tech</h2>
        <ProductGallery :images="techImages" />
      </div>

      <div>
        <h2 class="text-2xl font-bold text-blue-700 mb-4">Sua Leitura Garantida!</h2>
        <ProductGallery :images="bookImages" />
      </div>

      <div>
        <h2 class="text-2xl font-bold text-blue-700 mb-4">Para o conforto da sua casa</h2>
        <ProductGallery :images="homeImages" />
      </div>
    </div>
  </section>
</template>

<script setup>
import ProductGallery from '@/components/ProductGallery.vue'
import Navbar from '@/components/Navbar.vue'

import { ref, onMounted } from 'vue'
 
//    new URL('@/assets/banner1.png', import.meta.url).href,
const techImages = [
  'https://m.media-amazon.com/images/I/811fHsc2S8L.__AC_SX300_SY300_QL70_ML2_.jpg',
  'https://m.media-amazon.com/images/I/61k+PkiT62L._AC_SY300_SX300_.jpg',
  'https://m.media-amazon.com/images/I/71Z9DLS29FL.__AC_SY300_SX300_QL70_ML2_.jpg',
]

const bookImages = [
  'https://m.media-amazon.com/images/I/41j9V5PdvuL._SS135_.jpg',
  'https://m.media-amazon.com/images/I/41uXwKBLXCL._SX342_SY445_PQ95_.jpg',
  'https://m.media-amazon.com/images/I/51CYtCy4dzL._SS135_.jpg',
]

const homeImages = [
  'https://m.media-amazon.com/images/I/51Tus+N-CNL._AC_SY300_SX300_.jpg',
  'https://m.media-amazon.com/images/I/51ZdmJe+S7L._AC_SY300_SX300_.jpg',
  'https://m.media-amazon.com/images/I/614Z5I9bPYL.__AC_SX300_SY300_QL70_ML2_.jpg',
]

// Importando imagens locais
import promo1 from '@/assets/Banner1.1.png'
import promo2 from '@/assets/Banner2.png'
import promo3 from '@/assets/Banner3.png'

// Lista de imagens para o carrossel
const promos = ref([promo1, promo2, promo3])

const currentIndex = ref(0)
onMounted(() => {
  setInterval(() => {
    currentIndex.value = (currentIndex.value + 1) % promos.value.length
  }, 4000)
})
</script>

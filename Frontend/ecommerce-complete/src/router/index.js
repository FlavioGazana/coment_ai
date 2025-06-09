import { createRouter, createWebHistory } from 'vue-router'
import Home from '@/views/Home.vue'
import Login from '@/views/Login.vue'
import Cadastro from '@/views/Cadastro.vue'
import Produtos from '@/views/Produtos.vue'
import CadastroProduto from '@/views/CadastroProduto.vue'
import ProdutoDetalhes from '@/views/ProdutoDetalhes.vue'

const routes = [
  { path: '/',                name: 'Home',             component: Home },
  { path: '/login',           name: 'Login',            component: Login },
  { path: '/cadastro',        name: 'CadastroUser',     component: Cadastro },
  { path: '/cadastro-produto',name: 'CadastroProduto',  component: CadastroProduto },
  { path: '/produtos',        name: 'Produtos',         component: Produtos },
  { path: '/produto/:id',     name: 'ProdutoDetalhes',  component: ProdutoDetalhes }
]

const router = createRouter({
  history: createWebHistory(),
  routes
})

export default router

<template>
  <ul class="flex justify-center">
    <li
      v-for="item in menu.items"
      :key="item.title"
      class="mr-3"
      @click="toggleMenu(item)"
    >
      <nuxt-link
        class="bg-white inline-block py-4 px-6 font-semibold"
        :class="item.style"
        :to="item.route"
      >
        {{ item.title }}
      </nuxt-link>
    </li>
  </ul>
</template>

<script>
export default {
  data() {
    return {
      menu: {
        items: [
          {
            title: 'Catalog',
            route: '/',
            style: 'text-blue-700',
          },
          {
            title: 'My Cart',
            route: '/cart',
            style: 'text-gray-400',
          },
          {
            title: 'My Orders',
            route: '/orders',
            style: 'text-gray-400',
          },
        ],
      },
    };
  },
  mounted() {
    
  },
  methods: {
    toggleMenu(item) {
      this.menu.items.forEach(this.disable);
      this.enable(item);
    },
    disable(item) {
      item.style = 'text-gray-400';
    },
    enable(item) {
      item.style = 'text-blue-700';
    },
  },
};
</script>

<style>
</style>
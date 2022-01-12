<template>
  <div class="container mx-auto">
    <div class="grid grid-cols-5 gap-8">
      <product-card
        v-for="product in products"
        :key="product.productId"
        :product="product"
      >
      </product-card>
    </div>
  </div>
</template>

<script>
export default {
  name: 'IndexPage',
  data() {
    return {
      products: [],
      categories: [],
    };
  },
  mounted() {
    this.loadCategories();
    this.loadProducts();
  },
  methods: {
    async loadProducts() {
      const response = await this.$axios.$get('catalog');
      if (response.success) {
        this.products = response.data;
      } else {
        console.log(response.error);
      }
    },
    async loadCategories() {
      const response = await this.$axios.$get('catalog/categories');
      if (response.success) {
        this.categories = response.data;
      } else {
        console.log(response.error);
      }
    },
  },
};
</script>

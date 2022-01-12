<template>
  <div class="container mx-auto">
    <div id="catalog-categories" class="mt-2 mb-4 flex">
      <capsule-button
        v-for="category in categories"
        :key="category.caregoryId"
        :title="category.name"
        @on-clicked="onCategorySelected(category)"
      >
      </capsule-button>
    </div>
    <div id="catalog-items" class="grid grid-cols-5 gap-8">
      <product-card
        v-for="product in products"
        :key="product.productId"
        :product="product"
        @add-to-cart="addItemToCart(product)"
      >
      </product-card>
    </div>
  </div>
</template>

<script>
export default {
  name: 'IndexPage',
  data() {
    return {};
  },
  computed: {
    products() {
      return this.$store.state.catalog.products;
    },
    categories() {
      return this.$store.state.catalog.categories;
    },
  },
  created() {
    this.loadCategories();
    this.loadProducts();
  },
  methods: {
    async loadProducts() {
      const existingItems = this.$store.state.catalog.products;
      if (existingItems.length > 0) return;

      const response = await this.$axios.$get('catalog');
      if (response.success) {
        this.$store.commit('catalog/setProducts', response.data);
      }
    },
    async loadCategories() {
      const existingItems = this.$store.state.catalog.categories;
      if (existingItems.length > 0) return;

      const response = await this.$axios.$get('catalog/categories');
      if (response.success) {
        this.$store.commit('catalog/setCategories', response.data);
      }
    },
    addItemToCart(product) {
      this.selectedProduct = product;
      this.isDialogOpen = true;
    },
    onCategorySelected(category) {},
  },
};
</script>

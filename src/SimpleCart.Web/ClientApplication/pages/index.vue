<template>
  <div class="container mx-auto">
    <div id="catalog-categories" class="mt-2 mb-4 flex">
      <capsule-button
        v-for="category in categories"
        :key="category.caregoryId"
        :title="category.name"
        @on-selected="onCategorySelected(category)"
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
      const categories = [{ categoryId: null, name: 'All' }];
      categories.push(...this.$store.state.catalog.categories);
      return categories;
    },
  },
  created() {
    this.$store.dispatch('catalog/loadProducts');
    this.$store.dispatch('catalog/loadCategories');
    this.$store.dispatch('cart/initializeCart');
  },
  methods: {
    addItemToCart(product) {
      this.$store.dispatch('cart/addToCart', {
        productId: product.productId,
        quantity: 1,
      });
    },
    onCategorySelected(category) {
      this.$store.dispatch('catalog/loadProducts', {
        categoryId: category.categoryId,
      });
    },
  },
};
</script>

<template>
  <div class="container mx-auto flex">
    <div v-if="cart.items.length > 0" class="w-1/2">
      <cart-item
        v-for="item in cart.items"
        :key="item.productId"
        :product="item"
      >
      </cart-item>
    </div>
    <div v-else class="w-1/2">
      <empty-state
        image-url="/img/empty_cart.svg"
        title="Your cart is empty!"
        description="Click Add to cart from catalog"
      />
    </div>
    <div class="w-1/2 px-20 mt-8">
      <div class="rounded overflow-hidden shadow-lg mb-3 p-4 pt-8">
        <div class="grid grid-cols-1 divide-y divide-dashed px-4">
          <price-entry title="Total" :price="cart.total"></price-entry>
          <price-entry
            title="Delivery charge"
            :price="cart.deliveryCharge"
          ></price-entry>
          <price-entry title="Vat" :price="cart.vat"></price-entry>
          <price-entry title="Discount" :price="cart.discount"></price-entry>
          <price-entry title="Payable" :price="cart.payable"></price-entry>
        </div>
        <button
          class="
            bg-blue-500
            hover:bg-blue-700
            text-white
            font-bold
            py-2
            px-4
            rounded
            ml-4
            mt-4
          "
          @click="checkout"
        >
          Checkout
        </button>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'CartPage',
  data() {
    return {};
  },
  computed: {
    cart() {
      return this.$store.state.cart.cart;
    },
  },
  created() {
    this.$store.dispatch('cart/initializeCart');
  },
  methods: {
    checkout() {
      if (!this.$auth.loggedIn) {
        this.$auth.loginWith('aad');
        return;
      }
      this.$store.dispatch('cart/checkout');
    },
  },
};
</script>

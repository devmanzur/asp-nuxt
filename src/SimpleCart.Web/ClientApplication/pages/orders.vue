<template>
  <div>
    <div v-if="isLoggedIn">
      <div class="container mx-auto">
        <div v-if="orders.length > 0">
            
          <orders-table :orders="orders"> </orders-table>
        </div>
        <div v-else>
          <empty-state
            image-url="/img/no_orders.svg"
            title="You have not created any orders yet!"
            description="Checkout your cart to place an order"
          />
        </div>
      </div>
    </div>
    <div v-else class="text-center">
      <empty-state
        image-url="/img/unlock_account.svg"
        title="You are not signed in!"
        description="Please sign in to view your orders"
      />
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
        @click="signIn"
      >
        Sign in
      </button>
    </div>
  </div>
</template>

<script>
export default {
  name: 'OrdersPage',
  data() {
    return {};
  },
  computed: {
    isLoggedIn() {
      return this.$auth.loggedIn;
    },
    orders() {
      return this.$store.state.orders.orders;
    },
    selectedOrder() {
      return this.$store.state.orders.selectedOrder;
    },
  },
  created() {
    this.$store.dispatch('orders/getOrders');
  },
  methods: {
    signIn() {
      this.$auth.loginWith('aad');
    },
  },
};
</script>

<style>
</style>
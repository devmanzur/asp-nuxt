<template>
  <div>
    <div v-if="isLoggedIn">
      <div class="container mx-auto">
        <div v-if="orders.length > 0">
          <button
            class="
              px-4
              py-1
              my-2
              text-sm text-blue-600
              font-semibold
              rounded-full
              border border-blue-200
              hover:text-white hover:bg-blue-600 hover:border-transparent
              inline-flex
            "
            @click="onReloadClicked"
          >
            <svg
              xmlns="http://www.w3.org/2000/svg"
              class="h-5 w-5 mr-2"
              fill="none"
              viewBox="0 0 24 24"
              stroke="currentColor"
            >
              <path
                stroke-linecap="round"
                stroke-linejoin="round"
                stroke-width="2"
                d="M4 4v5h.582m15.356 2A8.001 8.001 0 004.582 9m0 0H9m11 11v-5h-.581m0 0a8.003 8.003 0 01-15.357-2m15.357 2H15"
              />
            </svg>
            Reload
          </button>
          <orders-table :orders="orders" />
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
    this.$store.dispatch('orders/getOrders', { reload: false });
  },
  methods: {
    signIn() {
      this.$auth.loginWith('aad');
    },
    onReloadClicked() {
      this.$store.dispatch('orders/getOrders', { reload: true });
    },
  },
};
</script>

<style>
</style>
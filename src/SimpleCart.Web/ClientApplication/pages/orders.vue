<template>
  <div>
    <div v-if="isLoggedIn">
      <h2>Your orders are here!</h2>
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
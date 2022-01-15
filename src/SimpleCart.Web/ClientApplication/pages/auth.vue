<template>
  <div class="grid place-items-center h-1/2">
    <div class="max-w-prose text-center">
      <img
        class="w-full object-cover"
        src="/img/authentication_success.png"
        alt="Sunset in the mountains"
      />
      <h2 class="md:text-md font-medium">Signed in successfully</h2>
      <p class="text-sm font-light text-gray-400">
        You will be redirected shortly
      </p>
    </div>
  </div>
</template>

<script>
export default {
  name: 'AuthPage',
  mounted() {
    const ctx = this;
    if (!this.$auth.loggedIn) {
      this.$auth.loginWith('aad');
    } else {
      this.delay(2000).then(() => ctx.$router.push('/'));
    }
  },
  methods: {
    delay(time) {
      return new Promise((resolve) => setTimeout(resolve, time));
    },
  },
};
</script>
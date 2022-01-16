<template>
  <div class="grid place-items-center h-1/2">
    <empty-state
      image-url="/img/account_secured.svg"
      title="Signed in successfully"
      description="You will be redirected shortly"
    />
  </div>
</template>

<script>
export default {
  name: 'AuthPage',
  mounted() {
    const ctx = this;
    this.delay(2000).then(() => ctx.$router.push('/'));
  },
  methods: {
    delay(time) {
      return new Promise((resolve) => setTimeout(resolve, time));
    },
  },
};
</script>
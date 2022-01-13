<template>
  <div class="px-2 py-4">
    <div class="flex justify-between items-center">
      <p class="text-sm font-medium">{{ title }}</p>
      <p class="text-sm font-medium">$ {{ price }}</p>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    title: {
      type: String,
      required: true,
    },
    price: {
      type: String,
      required: true,
    },
  },
};
</script>

<style>
</style>
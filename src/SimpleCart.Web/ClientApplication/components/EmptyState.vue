<template>
  <div class="grid place-items-center h-1/2">
    <div class="max-w-prose text-center">
      <img
        class="object-contain h-96 w-96"
        :src="imageUrl"
        alt="Sunset in the mountains"
      />
      <h2 class="md:text-md font-medium mt-2">{{ title }}</h2>
      <p class="text-sm font-light text-gray-400">
        {{ description }}
      </p>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    imageUrl: {
      type: String,
      required: true,
    },
    title: {
      type: String,
      required: true,
    },
    description: {
      type: String,
      required: true,
    },
  },
};
</script>

<style>
</style>
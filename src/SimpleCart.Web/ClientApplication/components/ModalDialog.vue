<template>
  <div class="h-screen flex items-center justify-center">
    <div class="modal rounded-lg shadow-lg bg-blue-900">
      <!-- Header -->
      <div class="border-b border-blue-800 text-blue-400">
        <div class="p-4">X</div>
      </div>

      <!-- Body -->
      <div class="p-4 pl-20 relative">
        <img
          class="absolute top-0 left-0 mt-4 ml-4 rounded-full"
          src="http://placekitten.com/g/50/50"
        />
        <textarea
          class="bg-transparent w-full pt-4 outline-none text-lg text-white"
          placeholder="What's happening?"
          rows="5"
        ></textarea>
      </div>

      <!-- Footer -->
      <div class="p-4 pl-20 flex justify-between">
        <div class="flex items-center text-3xl">
          <a class="inline-block mr-2">😎</a>
          <a class="inline-block mr-2">🥳</a>
          <a class="inline-block mr-2">😍</a>
          <a class="inline-block">🤗</a>
        </div>
        <div class="flex items-center">
          <button class="rounded-full bg-blue-500 py-2 px-4 text-blue-100">
            Tweet
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {};
</script>

<style>
.modal {
  min-width: 60%;
  background: #15202b;
}
</style>